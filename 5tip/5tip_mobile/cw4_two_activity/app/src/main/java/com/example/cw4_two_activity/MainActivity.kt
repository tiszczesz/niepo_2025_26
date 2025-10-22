package com.example.cw4_two_activity

import android.app.Activity
import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.activity.result.contract.ActivityResultContracts
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {

    companion object {
        const val EXTRA_INITIAL = "initialKey"
        const val EXTRA_RESULT = "resultKey"
    }

    private lateinit var tvResult: TextView

    private val launcher =
        registerForActivityResult(ActivityResultContracts.StartActivityForResult()) { result ->
            if (result.resultCode == Activity.RESULT_OK) {
                val newValue = result.data?.getStringExtra(EXTRA_RESULT)
                tvResult.text = "Otrzymano wynik: ${newValue ?: "<puste>"}"
            } else {
                tvResult.text = "Brak wyniku / anulowano"
            }
        }


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        tvResult = findViewById(R.id.tvResult)
        val btn = findViewById<Button>(R.id.button);
        btn.setOnClickListener {
            val intent = Intent(this,
                            SecondActivity::class.java).apply{
                putExtra(EXTRA_INITIAL, "Wartość startowa z MainActivity")
            }

            startActivity(intent)
        }
    }
}