package com.example.egztest

import android.os.Bundle
import android.widget.RadioButton
import android.widget.RadioGroup
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    var questions: List<Question> = listOf()
    var currentQuestionIndex: Int = 0
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        questions= listOf(
            Question(listOf("A", "B", "C", "D"), "A", "image_path_1"),
            Question(listOf("AA", "BB", "CC", "DD"), "BB", "image_path_2"),
            Question(listOf("AAAA", "BBB", "CCC", "DDD"), "CCC", "image_path_3")
        )
        val radioGroup: RadioGroup = findViewById<RadioGroup>(R.id.radioGroup)
        val rb1: RadioButton = findViewById<RadioButton>(R.id.radioButton1)
        val rb2: RadioButton = findViewById<RadioButton>(R.id.radioButton2)
        val rb3: RadioButton = findViewById<RadioButton>(R.id.radioButton3)
        val rb4: RadioButton = findViewById<RadioButton>(R.id.radioButton4)
        loadQuestion(0,rb1,rb2,rb3,rb4)
        radioGroup.setOnCheckedChangeListener { group, checkedId ->
            // Handle radio button selection
            val info = group.findViewById<android.widget.RadioButton>(checkedId).text
            Toast.makeText(this, "Selected option ID: $checkedId tresc: $info", Toast.LENGTH_SHORT).show()
        }
        val btn1 = findViewById<android.widget.Button>(R.id.buttonNext)
        btn1.setOnClickListener {
            currentQuestionIndex++
            if (currentQuestionIndex >= questions.size) {
                currentQuestionIndex = 0
            }
            loadQuestion(currentQuestionIndex,rb1,rb2,rb3,rb4)
        }
    }
    fun loadQuestion(index: Int,rb1: RadioButton,rb2: RadioButton,rb3: RadioButton,rb4: RadioButton) {
        if (index < questions.size) {
            val question = questions[index]
            rb1.text = question.list[0]
            rb2.text = question.list[1]
            rb3.text = question.list[2]
            rb4.text = question.list[3]

        }
    }
}