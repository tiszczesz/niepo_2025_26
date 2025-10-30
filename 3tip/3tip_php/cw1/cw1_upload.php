<pre>
<?php
var_dump($_FILES);
//echo __DIR__;
$target_dir = __DIR__ . '/uploads/';
//zmienna kontrolujaca czy wystapil blad podczas uploadu
$target_file = $target_dir
    . basename($_FILES["fileUpload"]["name"]);
var_dump($target_file);
$error_upload = 1;
//echo $target_dir;
$fileType = strtolower(string: pathinfo(path: $target_file,
           flags: PATHINFO_EXTENSION));
?>
</pre>