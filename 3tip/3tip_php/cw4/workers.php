<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
    <title>Document</title>
</head>
<body>
    <h2>Lista pracowników</h2>
    <?php
    require_once 'models/Person.php';
    require_once 'models/Worker.php';
    require_once 'models/FirmRepo.php';
    $repo = new FirmRepo();
    $workers = $repo->getWorkers();
    if (count($workers) === 0) {
        echo "<p>Brak pracowników w bazie danych</p>";
    } else {
        echo "<table class='table table-striped'>";
        echo "<thead><tr><th>Imię</th><th>Nazwisko</th><th>Wiek</th><th>Funkcja</th><th>Godziny pracy</th></tr></thead>";
        echo "<tbody>";
        foreach ($workers as $worker) {
            echo "<tr>";
            echo "<td>" . htmlspecialchars($worker->getFirstName()) . "</td>";
            echo "<td>" . htmlspecialchars($worker->getLastName()) . "</td>";
            echo "<td>" . htmlspecialchars($worker->getAge()) . "</td>";
            echo "<td>" . htmlspecialchars($worker->getJobFunction()) . "</td>";
            echo "<td>" . htmlspecialchars($worker->getWorkHours()) . "</td>";
            echo "</tr>";
        }
        echo "</tbody></table>";
    }

   
    ?>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>
</html>