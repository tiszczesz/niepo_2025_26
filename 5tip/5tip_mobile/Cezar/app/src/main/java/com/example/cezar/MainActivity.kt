package com.example.cezar

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.SeekBar
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
        val textToConvert = findViewById<EditText>(R.id.etToConvert)
        val sbKey = findViewById<SeekBar>(R.id.sbKey)
        val etKey = findViewById<TextView>(R.id.infKey)
        val btnRun = findViewById<Button>(R.id.btnRun)
        val tvResult = findViewById<TextView>(R.id.tvResult)
        sbKey.setOnSeekBarChangeListener(object : SeekBar.OnSeekBarChangeListener {
            override fun onProgressChanged(
                p0: SeekBar?,
                p1: Int,
                p2: Boolean
            ) {
                etKey.text = p1.toString()
            }

            override fun onStartTrackingTouch(p0: SeekBar?) {
                //  TODO("Not yet implemented")
            }

            override fun onStopTrackingTouch(p0: SeekBar?) {
                //  TODO("Not yet implemented")
            }
        })
    btnRun.setOnClickListener {
        val myCezar = MyCezar(sbKey.progress)
        val encrypted = myCezar.encrypt(textToConvert.text.toString())
        tvResult.text = encrypted
    }

    }
}