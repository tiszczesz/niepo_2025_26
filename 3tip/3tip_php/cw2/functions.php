<?php
function GetConnection(): mysqli | null
{
    $conn = new mysqli("localhost", "root", "", "4tip_students_2025_26");
    if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    }
    return $conn;
}
function GetAllStudents(): array
{
    $conn = GetConnection();
    $students = [];
    if ($conn) {
        $sql = "SELECT * FROM students";
        $result = $conn->query($sql);
        if ($result->num_rows > 0) {
            while ($row = $result->fetch_assoc()) {
                $students[] = $row;
            }
        }
        $conn->close();
    }
    return $students;
}
function StudentsToTable(array $students): string
{
    if (empty($students)) {
        return "<p>No students found.</p>";
    }
    $html = <<< HTML
<table class="table" id="mojaTabela" table-striped">
    <thead>
        <tr>     
            <th>Lp</th>       
            <th>Imię</th>
            <th>Nazwisko</th>
            <th>Data urodzenia</th>
        </tr>
    </thead>
    <tbody>   
HTML;
    $lp = 0;
    foreach ($students as $index => $student) {
        $lp++;
        $html .= <<< HTML
        <tr>
            <td>{$lp}</td>
            <td>{$student['firstname']}</td>
            <td>{$student['lastname']}</td>            
            <td>{$student['birthDate']}</td>
        </tr>
HTML;
    }
    $html .= <<< HTML
    </tbody>
</table>
HTML;
    return $html;
}
