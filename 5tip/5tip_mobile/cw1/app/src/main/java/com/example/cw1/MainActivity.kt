package com.example.cw1

import android.os.Bundle
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
        val seekBar = findViewById<SeekBar>(R.id.seekBar)
        seekBar.max = 100;
        seekBar.min = 0;
        val result = findViewById<TextView>(R.id.textView2)
        seekBar.setOnSeekBarChangeListener(object : SeekBar.OnSeekBarChangeListener{
            override fun onProgressChanged(
                p0: SeekBar?,
                p1: Int,
                p2: Boolean
            ) {
                result.text = p1.toString()
            }

            override fun onStartTrackingTouch(p0: SeekBar?) {
                //TODO("Not yet implemented")
            }

            override fun onStopTrackingTouch(p0: SeekBar?) {
               // TODO("Not yet implemented")
            }
        })
    }
}