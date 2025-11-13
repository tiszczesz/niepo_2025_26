<?php
function getConnection(): mysqli
{
    $host = 'localhost';
    $db = 'szachy';
    $user = 'root';
    $pass = null;
    $conn = new mysqli($host, $user, $pass, $db);
    if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    }
    return $conn;
}
function getAllUsers(mysqli $conn): array
{
    $sql = "SELECT id_zawodnika, pseudonim, tytul,data_zdobycia,ranking,klasa FROM zawodnicy";
    $result = $conn->query($sql);
    $users = [];
    if ($result->num_rows > 0) {
        while ($row = $result->fetch_assoc()) {
            $users[] = $row;
        }
    }
    return $users;
}

function getUserById(mysqli $conn, int $id): ?array
{
    $sql = "SELECT id_zawodnika, pseudonim, tytul, data_zdobycia, ranking, klasa 
            FROM zawodnicy WHERE id_zawodnika = $id";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        return $result->fetch_assoc();
    }
    return null;
}

function closeConnetion(mysqli $conn): void
{
    $conn->close();
}

function addUser(mysqli $conn, array $data): array
{
    // Walidacja danych
    if (empty($data['pseudonim'])) {
        return ['success' => false, 'message' => 'Pseudonim jest wymagany'];
    }

    if (empty($data['tytul'])) {
        return ['success' => false, 'message' => 'Tytul jest wymagany'];
    }

    $pseudonim = $conn->real_escape_string($data['pseudonim']);
    $tytul = $conn->real_escape_string($data['tytul']);
    $data_zdobycia = isset($data['data_zdobycia']) ? $conn->real_escape_string($data['data_zdobycia']) : null;
    $ranking = isset($data['ranking']) ? (int)$data['ranking'] : null;
    $klasa = isset($data['klasa']) ? $conn->real_escape_string($data['klasa']) : null;

    $sql = "INSERT INTO zawodnicy (pseudonim, tytul, data_zdobycia, ranking, klasa) 
            VALUES ('$pseudonim', '$tytul', " .
        ($data_zdobycia ? "'$data_zdobycia'" : "NULL") . ", " .
        ($ranking ? $ranking : "NULL") . ", " .
        ($klasa ? "'$klasa'" : "NULL") . ")";

    if ($conn->query($sql) === TRUE) {
        return [
            'success' => true,
            'message' => 'Zawodnik dodany pomyślnie',
            'id' => $conn->insert_id
        ];
    } else {
        return [
            'success' => false,
            'message' => 'Błąd: ' . $conn->error
        ];
    }
}

function deleteUser(mysqli $conn, int $id): array
{
    // Sprawdź czy zawodnik istnieje
    $check_sql = "SELECT id_zawodnika FROM zawodnicy WHERE id_zawodnika = $id";
    $check_result = $conn->query($check_sql);

    if ($check_result->num_rows === 0) {
        return [
            'success' => false,
            'message' => 'Zawodnik o podanym ID nie istnieje'
        ];
    }

    // Usuń zawodnika
    $sql = "DELETE FROM zawodnicy WHERE id_zawodnika = $id";

    if ($conn->query($sql) === TRUE) {
        return [
            'success' => true,
            'message' => 'Zawodnik usunięty pomyślnie',
            'deleted_id' => $id
        ];
    } else {
        return [
            'success' => false,
            'message' => 'Błąd: ' . $conn->error
        ];
    }
}
