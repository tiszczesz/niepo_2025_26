package com.example.cw1_android

import android.icu.util.GregorianCalendar
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        //zainicjowanie kontrolek button i textview
        val button = findViewById<Button>(R.id.button)
        val textView = findViewById<TextView>(R.id.textView2)
        val button2 = findViewById<Button>(R.id.button2)
        val textView3 = findViewById<TextView>(R.id.textView3)

        //zmieniamy napis na textview przy starcie aplikacji
        textView.text = "Hello World!"

        //ustawiamy listener na button, który zmienia napis na textview po kliknięciu
        button.setOnClickListener {
            textView.text = "Button Clicked!"
        }
        button2.setOnClickListener {
            val callendar = GregorianCalendar()
            textView3.text = "Current date and time: ${callendar.time}"
        }

    }
}