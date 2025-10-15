package com.example.cw3_list

import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.ListView
import android.widget.Toast
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

        val editContact = findViewById<EditText>(R.id.contactId)
        val btnAdd = findViewById<Button>(R.id.btnAdd)
        //dodanie listy contacts do ListView
        val listView = findViewById<ListView>(R.id.listViewId)
        //tworzenie adaptera
        val contactAdapter = ArrayAdapter<String>(
            this,
            android.R.layout.simple_list_item_1,
            contacts
        )
        //przypisanie adaptera do ListView
        listView.adapter = contactAdapter
        //dodanie kontaktu do listy po kliknięciu przycisku
        btnAdd.setOnClickListener {
            val newContact = editContact.text.toString().trim()
            if(newContact.isNotEmpty()){
                contacts.add(newContact)
                //wywolanie notifyDataSetChanged() aby odswiezyc ListView
                contactAdapter.notifyDataSetChanged()
                editContact.text.clear()
            }else{
                Toast.makeText(this,"Brak danych", Toast.LENGTH_LONG).show()
            }
        }
        //reakcja na klikniecie elementu listy
        listView.setOnItemClickListener { parent, view, position, id ->
            val selectedContact = contacts[position];
            Toast.makeText(
                this, "Wybrano: $selectedContact",
                Toast.LENGTH_LONG
            ).show()
        }
        //reakcja na dlugie klikniecie elementu listy - usuniecie elementu
        listView.setOnItemLongClickListener { parent, view, position, id ->
            contacts.removeAt(position)
            contactAdapter.notifyDataSetChanged()
            true
        }

    }
}