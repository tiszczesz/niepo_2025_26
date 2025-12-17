<?php
require_once 'config.php';
class FirmRepo
{
    private mysqli $dbConnection;
    public function __construct(  ) {       
    }
    public function getConnection(): ?mysqli
    {
        $this->dbConnection = new mysqli(
            DBHOST,
            DBUSER,
            DBPASSWORD,
            DBASENAME
        );
        if ($this->dbConnection->connect_errno) {
            return null;
        }
        return $this->dbConnection;
    }
    function getPersons():array {
        $result  = [];
        $conn = $this->getConnection();
        if ($conn === null) {
            return $result;
        }
        $sql = "SELECT id, firstname, lastname, age FROM persons";
        $res = $conn->query($sql);
        if ($res === false) {
            return $result;
        }
        while ($row = $res->fetch_assoc()) {
            $person = new Person(
                $row['id'],
                $row['firstname'],
                $row['lastname'],
                (int)$row['age']
            );
            $result[] = $person;
        }
        return $result;
    }
    // function getStudents():array {
        
    // }

}
