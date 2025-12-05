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
    $s1 = new Student(gAvg: 4.5 );
    $t1 = new Teacher(
        'Jan',
        'Kowalski',
        40,
        'T123',
        5000.0,
        ['Matematyka', 'Fizyka']
    );
    var_dump($s1);
    var_dump($t1);
    echo $s1;
    echo "<br>";
    echo $t1;
    ?>
</body>
</html>