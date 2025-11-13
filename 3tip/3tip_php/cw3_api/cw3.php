<?php
require_once 'functions.php';
header('Content-Type: application/json');

$conn = getConnection();
$method = $_SERVER['REQUEST_METHOD'];

if ($method === 'GET') {
    // Pobierz zawodnika po ID lub wszystkich zawodników
    if (isset($_GET['id'])) {
        $id = (int)$_GET['id'];
        $user = getUserById($conn, $id);
        if ($user) {
            echo json_encode($user);
        } else {
            http_response_code(404);
            echo json_encode([
                'success' => false,
                'message' => 'Zawodnik nie znaleziony'
            ]);
        }
    } else {
        $users = getAllUsers($conn);
        echo json_encode($users);
    }
} elseif ($method === 'POST') {
    // Dodaj nowego zawodnika
    $data = json_decode(file_get_contents('php://input'), true);

    if ($data) {
        $result = addUser($conn, $data);
        if ($result['success']) {
            http_response_code(201); // Created
            echo json_encode($result);
        } else {
            http_response_code(400); // Bad Request
            echo json_encode($result);
        }
    } else {
        http_response_code(400);
        echo json_encode([
            'success' => false,
            'message' => 'Nieprawidłowe dane JSON'
        ]);
    }
} elseif ($method === 'DELETE') {
    // Usuń zawodnika - ID z URL lub z body JSON
    $id = null;

    // Sprawdź czy ID jest w URL
    if (isset($_GET['id'])) {
        $id = (int)$_GET['id'];
    } else {
        // Sprawdź czy ID jest w body JSON
        $data = json_decode(file_get_contents('php://input'), true);
        if ($data && isset($data['id'])) {
            $id = (int)$data['id'];
        }
    }

    if ($id) {
        $result = deleteUser($conn, $id);
        if ($result['success']) {
            http_response_code(200); // OK
            echo json_encode($result);
        } else {
            http_response_code(404); // Not Found
            echo json_encode($result);
        }
    } else {
        http_response_code(400);
        echo json_encode([
            'success' => false,
            'message' => 'ID zawodnika jest wymagane'
        ]);
    }
} else {
    http_response_code(405); // Method Not Allowed
    echo json_encode([
        'success' => false,
        'message' => 'Metoda nie jest obsługiwana'
    ]);
}

closeConnetion($conn);
