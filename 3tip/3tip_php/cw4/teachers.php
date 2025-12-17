<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
    <title>Document</title>
</head>

<body>
    <h3>Lista nauczycieli</h3>
    <ul class="list-group"></ul>
    <?php
    require_once 'models/Person.php';
    require_once 'models/Teacher.php';
    require_once 'models/FirmRepo.php';

    $repo = new FirmRepo();
    $teachers = $repo->getTeachers();
    foreach ($teachers as $teacher) {
        echo "<li class=\"list-group-item\">$teacher</li>";
    }
    echo "</ul>\n";
    ?>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>

</html>