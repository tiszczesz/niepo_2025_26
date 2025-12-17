<!DOCTYPE html>
<html lang="pl">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <?php
    require_once 'models/Person.php';
    require_once 'models/Student.php';
    require_once 'models/Teacher.php';
    require_once 'models/Worker.php';
    require_once 'models/FirmRepo.php';
    $repo = new FirmRepo();
    $persons = $repo->getPersons();
   // var_dump($persons);
    ?>
    <div>
        <ul>
            <li><a href="students.php">Lista studentów</a></li>
            <li><a href="teachers.php">Lista nauczycieli</a></li>
            <li><a href="workers.php">Lista pracowników</a></li>
        </ul>

    </div>

</body>

</html>