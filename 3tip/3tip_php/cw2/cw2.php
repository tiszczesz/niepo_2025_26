<?php
$cookies_name = "user";
$cookies_value = "re eer er123";
setcookie(
    $cookies_name,
    $cookies_value,
    time() + 86400
); // 86400 = 1 day
setcookie("test_cookie", "test");
?>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
    <title>Ćwiczenie 2 - cookies</title>
</head>

<body>
    <h1>Ćwiczenie 2 - cookies</h1>
    <?php
    echo "<pre>";
    var_dump($_COOKIE);
    echo "</pre>";
    if (!isset($_COOKIE[$cookies_name])) {
        echo "<p>Nazwa ciasteczka '" . $cookies_name . "' nie jest ustawiona!</p>";
    } else {
        echo "<p>Ciasteczko '" . $cookies_name . "' jest ustawione!<br>";
        echo "Wartość: " . $_COOKIE[$cookies_name] . "</p>";
    }
    setcookie($cookies_name, "Nowa wartość", time() + 3600);
    var_dump($_COOKIE);
    // unset($_COOKIE[$cookies_name]);
    // var_dump($_COOKIE);
    //setcookie($cookies_name, "", time() - 3600); // usuwanie ciasteczka
    ?>

    <main>
        <h3>Tabelka</h3>
        <?php
        require_once "functions.php";
        $students = GetAllStudents();
        echo StudentsToTable($students);
        ?>
    </main>
    <script src="script.js" defer></script>
</body>

</html>