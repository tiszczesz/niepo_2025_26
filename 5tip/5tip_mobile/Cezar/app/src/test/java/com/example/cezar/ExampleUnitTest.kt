package com.example.cezar

import org.junit.Test

import org.junit.Assert.*

/**
 * Example local unit test, which will execute on the development machine (host).
 *
 * See [testing documentation](http://d.android.com/tools/testing).
 */
class ExampleUnitTest {
    @Test
    fun addition_isCorrect() {
        assertEquals(4, 2 + 2)
    }
    @Test
    fun testEncrypt() {
        val myCezar = MyCezar(3)
        val encrypted = myCezar.encrypt("Hello, World!")
        assertEquals("Khoor, Zruog!", encrypted)
    }
    @Test
    fun testEncryptZeroKey() {
        val myCezar = MyCezar(0)
        val encrypted = myCezar.encrypt("Hello, World!")
        assertEquals("Hello, World!", encrypted)
    }
    @Test
    fun testEncryptMoreThen26() {
        val myCezar = MyCezar(29) // 29 % 26 == 3
        val encrypted = myCezar.encrypt("Hello, World!")
        assertEquals("Khoor, Zruog!", encrypted)
    }
}