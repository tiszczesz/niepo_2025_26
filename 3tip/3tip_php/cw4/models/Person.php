<?php
class Person
{
    protected string $firstName;
    protected string $lastName;
    protected int $age;
    public function __construct(string $firstName = '', string $lastName = '', int $age = 0)
    {
        $this->firstName = $firstName;
        $this->lastName = $lastName;
        $this->age = $age;
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
