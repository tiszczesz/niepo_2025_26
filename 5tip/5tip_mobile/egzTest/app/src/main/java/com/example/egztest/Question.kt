package com.example.egztest

class Question(val list: List<String>, val answer: String, val imagePath: String) {
    fun checkedAnswer(selectedAnswer: String): Boolean {
        return selectedAnswer == answer
    }
}