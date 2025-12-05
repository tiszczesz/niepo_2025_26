<?php
class Person
{  // Właściwości klasy Person automatycznie zdefiniowane w konstruktorze
    public function __construct(
        protected string $firstName = '',
        protected string $lastName = '',
        protected int $age = 0)
    {
    }
    public function getFirstName(): string
    {
        return $this->firstName;
    }
    public function getLastName(): string
    {
        return $this->lastName;
    }
    public function getAge(): int
    {
        return $this->age;
    }
    public function __toString(): string
    {
        return "Imię: " . $this->firstName . ", Nazwisko: "
            . $this->lastName . ", Wiek: " . $this->age;
    }
}
