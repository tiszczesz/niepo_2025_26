<?php
class Student extends Person
{

    public function __construct(
        protected int $id = -1,
        protected string $firstName = '',
        protected string $lastName = '',
        protected int $age = 0,
        protected string $studentId = '',
        protected float $gAvg = 10.0
    ) {
        // Wywołanie konstruktora klasy bazowej (Person) ustawia właściwości odziedziczone
        parent::__construct($id,$firstName, $lastName, $age);
        // Ustawienie właściwości specyficznych dla Student
        // $this->studentId = $studentId;
        // $this->gAvg = 67;
    }
    public function getStudentId(): string
    {
        return $this->studentId;
    }
    public function getGAvg(): float
    {
        return $this->gAvg;
    }
    // Nadpisanie metody __toString(), aby uwzględnić właściwości Studenta
    public function __toString(): string
    {
        return parent::__toString() . ", ID Studenta: " . $this->studentId
            . ", Średnia: " . $this->gAvg;
    }
}
