<?php
class Student extends Person
{
    protected string $studentId;
    protected float $gAvg;
    public function __construct(
        string $firstName = '',
        string $lastName = '',
        int $age = 0,
        string $studentId = '',
        float $gAvg = 0.0
    ) {
        // Wywołanie konstruktora klasy bazowej (Person) ustawia właściwości odziedziczone
        parent::__construct($firstName, $lastName, $age);
        // Ustawienie właściwości specyficznych dla Student
        $this->studentId = $studentId;
        $this->gAvg = $gAvg;
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
