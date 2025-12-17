<?php
require_once 'IEmployee.php';
class Teacher extends Person implements IEmployee
{   
 
    public function __construct(
        protected int $id = -1,
        protected string $firstName = '',
        protected string $lastName = '',
        protected int $age = 0,       
        protected float $salary = 0.0,
        protected array $subjects = []
    ) {
        // Wywołanie konstruktora klasy bazowej (Person) 
        // ustawia właściwości odziedziczone
        parent::__construct(
            $id,
            $firstName,
            $lastName,
            $age
        );
        // Ustawienie właściwości specyficznych dla Teacher        
        $this->salary = $salary;
        $this->subjects = $subjects;
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
        return parent::__toString() .  ", Wynagrodzenie: " . $this->salary
            . ((count($this->subjects) > 0)
                ? ", Przedmioty: [" . $subjectsStr . "]" : "");
    }
    public function DoWork(): string
    {
        return "Nauczam przedmioty: " 
          . implode(", ", $this->subjects) . ".";
    }
}
