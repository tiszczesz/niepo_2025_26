<?php
require_once 'config.php';
require_once 'Person.php';
require_once 'Student.php';
require_once 'Teacher.php';
require_once 'Worker.php';
class FirmRepo
{
    private mysqli $dbConnection;
    public function __construct() {}
    public function getConnection(): ?mysqli
    {
        $this->dbConnection = new mysqli(
            DBHOST,
            DBUSER,
            DBPASSWORD,
            DBASENAME
        );
        if ($this->dbConnection->connect_errno) {
            return null;
        }
        return $this->dbConnection;
    }
    function getPersons(): array
    {
        $result  = [];
        $conn = $this->getConnection();
        if ($conn === null) {
            return $result;
        }
        $sql = "SELECT id, firstname, lastname, age FROM persons";
        $res = $conn->query($sql);
        if ($res === false) {
            return $result;
        }
        while ($row = $res->fetch_assoc()) {
            $person = new Person(
                $row['id'],
                $row['firstname'],
                $row['lastname'],
                (int)$row['age']
            );
            $result[] = $person;
        }
        return $result;
    }
    // function getStudents():array {

    // }
    function getWorkers(): array
    {
        $conn = $this->getConnection();
        $result  = [];
        if ($conn === null) {
            return $result;
        }
        $sql = "SELECT persons.id, persons.firstname, persons.lastname, persons.age, workers.jobFunction, workers.workHours " .
            "FROM persons  INNER join workers on persons.id = workers.personID";
        $res = $conn->query($sql);
        if ($res === false) {
            return $result;
        }
        while ($row = $res->fetch_assoc()) {
            $worker = new Worker(
                $row['id'],
                $row['firstname'],
                $row['lastname'],
                (int)$row['age'],
                $row['jobFunction'],
                (int)$row['workHours']
            );
            $result[] = $worker;
        }
        $conn->close();
        return $result;
    }
    function getStudents(): array
    {
        $conn = $this->getConnection();
        $result  = [];
        if ($conn === null) {
            return $result;
        }
        $sql = "SELECT persons.id, persons.firstname, persons.lastname, persons.age, students.gAvg, students.studentID " .
            "FROM persons  INNER join students on persons.id = students.personID";
        $res = $conn->query($sql);
        if ($res === false) {
            return $result;
        }
        while ($row = $res->fetch_assoc()) {
            $student = new Student(
                $row['id'],
                $row['firstname'],
                $row['lastname'],
                (int)$row['age'],
                $row['studentID'],
                (int)$row['gAvg']
            );
            $result[] = $student;
        }
        $conn->close();
        return $result;
    }
    function getTeachers(): array
    {
        $conn = $this->getConnection();
        $result  = [];
        if ($conn === null) {
            return $result;
        }
        $sql = "SELECT persons.id, persons.firstname, persons.lastname, persons.age, teachers.salary " .
            "FROM persons  INNER join teachers on persons.id = teachers.personID";
        $res = $conn->query($sql);
        if ($res === false) {
            return $result;
        }
        while ($row = $res->fetch_assoc()) {
            //var_dump($row);
            $sqlSubjects = "SELECT `name` FROM subjects INNER JOIN teacher_subject  on subjects.id=teacher_subject.subjectID where teacherID = {$row['id']};";
            $resSubjects = $conn->query($sqlSubjects);
            $teacherSubjects = [];
            if ($resSubjects !== false) {
                while ($subjRow = $resSubjects->fetch_assoc()) {
                    $teacherSubjects[] = $subjRow['name'];
                }
            }
            $teacher = new Teacher(
                $row['id'],
                $row['firstname'],
                $row['lastname'],
                (int)$row['age'],
                (int)$row['salary'],
                $teacherSubjects
            );
            $result[] = $teacher;
        }
        $conn->close();
        return $result;
    }
}
