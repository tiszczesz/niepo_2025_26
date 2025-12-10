<?php
class Person
{  // Właściwości klasy Person automatycznie zdefiniowane w konstruktorze
    public function __construct(
        protected int $id = -1,
        protected string $firstName = '',
        protected string $lastName = '',
        protected int $age = 0)
    {
    }
    public function getId(): int
    {
        return $this->id;
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
