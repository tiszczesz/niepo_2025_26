<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <?php
    require_once 'models/Person.php';
    require_once 'models/Student.php';
    $s1 = new Student();
    var_dump($s1);
    echo $s1;
    ?>
</body>
</html>