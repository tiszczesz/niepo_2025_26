package com.example.cezar

class MyCezar(private val key: Int) {
    fun encrypt(plainText: String): String {
        return plainText.map { char ->
            when {
                char.isUpperCase() -> 'A' + (char - 'A' + key) % 26
                char.isLowerCase() -> 'a' + (char - 'a' + key) % 26
                else -> char
            }
//            char+key
        }.joinToString("")
    }


}