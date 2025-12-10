<?php

class Worker extends Person implements IEmployee{
    //funkcja i czas pracy
    public function __construct(
        int $id=-1,
        string $firstName = '',
        string $lastName = '',
        int $age = 0,
        protected string $jobFunction = '',
        protected float $workHours = 0.0
    ) {
        parent::__construct($id,$firstName, $lastName, $age);
    }
    public function getJobFunction(): string
    {
        return $this->jobFunction;
    }
    public function getWorkHours(): float
    {
        return $this->workHours;
    }
    public function __toString(): string
    {
        return parent::__toString() . ", Funkcja: " . $this->jobFunction
            . ", Czas pracy: " . $this->workHours . " godzin";
    }
    public function DoWork(): string
    {
        return "Wykonuję pracę jako " . $this->jobFunction . " przez "
            . $this->workHours . " godzin.";
    }
}