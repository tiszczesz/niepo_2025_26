<?php
class Teacher extends Person
{
    protected string $employeeId;
    protected float $salary;
    protected array $subjects;
    public function __construct(
        string $firstName = '',
        string $lastName = '',
        int $age = 0,
        string $employeeId = '',
        float $salary = 0.0,
        array $subjects = []
    ) {
        // Wywołanie konstruktora klasy bazowej (Person) 
        // ustawia właściwości odziedziczone
        parent::__construct(
            $firstName,
            $lastName,
            $age
        );
        // Ustawienie właściwości specyficznych dla Teacher
        $this->employeeId = $employeeId;
        $this->salary = $salary;
        $this->subjects = $subjects;
    }
    public function getEmployeeId(): string
    {
        return $this->employeeId;
    }
    public function getSalary(): float
    {
        return $this->salary;
    }
    public function getSubjects(): array
    {
        return $this->subjects;
    }
    // Nadpisanie metody __toString(), aby uwzględnić właściwości Teacher
    public function __toString(): string
    {
        $subjectsStr = implode(", ", $this->subjects);
        return parent::__toString() . ", ID Pracownika: " . $this->employeeId
            . ", Wynagrodzenie: " . $this->salary
            . ((count($this->subjects) > 0)
                ? ", Przedmioty: [" . $subjectsStr . "]" : "");
    }
}
