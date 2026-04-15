package com.example.cw2

import android.os.Bundle
import android.widget.ImageView
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
        val randomTexts = listOf(
            "żaba nie zajac nie ucieknie",
            "nosił żółw razy sześć, ponieśli i żabę",
            "pierze żabami nie szkodzi",
            "nie chwal dnia przed kumkaniem",
            "nie wszystko złoto co się świeci, nie każda żaba jest zielona"
        )
        //tutaj logika dla kontrolek
        //wyszukanie potrzebnych elementów
        val imageFrog = findViewById<ImageView>(R.id.imViewFrog)
        val info = findViewById<TextView>(R.id.textView2)
        //podpięcie zdarzenia click do obrazka
        imageFrog.setOnClickListener {
            //zmiana teksu w info
            info.text = randomTexts.random()
        }
        //zmiana src obrazka
        //imageFrog.setImageResource(R.drawable.frog2)
    }
}