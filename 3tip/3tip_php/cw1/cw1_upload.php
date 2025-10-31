<pre>
<?php
var_dump($_FILES);
//echo __DIR__;
$target_dir = __DIR__ . '/uploads/';

$target_file = $target_dir
    . basename($_FILES["fileUpload"]["name"]);
var_dump($target_file);
//zmienna kontrolujaca czy wystapil blad podczas uploadu
$error_upload = 1;
//echo $target_dir;
$fileType = strtolower(string: pathinfo(
    path: $target_file,
    flags: PATHINFO_EXTENSION
));
var_dump(pathinfo(
    path: $target_file,
    flags: PATHINFO_ALL
));
echo "File type: " . $fileType . "<br>";
//sprawdzenie czy plik jest obrazkiem
$check = getimagesize(filename: $_FILES["fileUpload"]["tmp_name"]);
var_dump($check);
if($check !== false){
    echo "Plik jest obrazkiem - " . $check["mime"] . "<br>";
    $error_upload = 1;
} else {
    echo "Plik nie jest obrazkiem.<br>";
    $error_upload = 0;
}
//sprawdzenie czy plik juz istnieje wczesniej
if(file_exists($target_file)){
    echo "Plik juz istnieje.<br>";
    $error_upload = 0;
}
//sprawdzenie rozmiaru pliku
if($_FILES["fileUpload"]["size"] > 500000){
    echo "Plik jest za duzy.<br>";
    $error_upload = 0;
}
//sprawdzenie formatu pliku
if($fileType != "jpg" && $fileType != "png" && $fileType != "jpeg"
    && $fileType != "gif"
){
    echo "Dozwolone sa tylko pliki JPG, JPEG, PNG i GIF.<br>";
    $error_upload = 0;
}
//sprawdzenie czy wystapil blad podczas uploadu
if($error_upload == 0){
    echo "Plik nie zostal wgrany z powodu bledow.<br>";
} else {
    //proba wgrania pliku
    if(move_uploaded_file(
        from: $_FILES["fileUpload"]["tmp_name"],
        to: $target_file
    )){
        echo "<p>Plik został wgrany:</p>";
        var_dump(scandir($target_dir));
    }
}
?>
</pre>