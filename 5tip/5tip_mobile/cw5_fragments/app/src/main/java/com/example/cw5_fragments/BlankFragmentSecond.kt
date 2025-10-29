package com.example.cw5_fragments

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.AdapterView
import android.widget.ArrayAdapter
import android.widget.Spinner
import android.widget.Toast

// TODO: Rename parameter arguments, choose names that match
// the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
private const val ARG_PARAM1 = "param1"
private const val ARG_PARAM2 = "param2"

/**
 * A simple [Fragment] subclass.
 * Use the [BlankFragmentSecond.newInstance] factory method to
 * create an instance of this fragment.
 */
class BlankFragmentSecond : Fragment(R.layout.fragment_blank_second) {



//    // TODO: Rename and change types of parameters
//    private var param1: String? = null
//    private var param2: String? = null
//
//    override fun onCreate(savedInstanceState: Bundle?) {
//        super.onCreate(savedInstanceState)
//        arguments?.let {
//            param1 = it.getString(ARG_PARAM1)
//            param2 = it.getString(ARG_PARAM2)
//        }
//    }
//
//    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?,
 //                            savedInstanceState: Bundle?): View? {
//        // Inflate the layout for this fragment
//        return inflater.inflate(R.layout.fragment_blank_second, container, false)
//    }
override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
    super.onViewCreated(view, savedInstanceState)

    // znajdź spinner w widoku fragmentu
    val spinner: Spinner = view.findViewById(R.id.spinner2)
    val adapter = ArrayAdapter(requireContext(), android.R.layout.simple_spinner_item, data)
    adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
    spinner.adapter = adapter
//    spinner.setOnClickListener {
//        val selectedItem = spinner.selectedItem.toString()
//        Toast.makeText(requireContext(), "Wybrano: $selectedItem", Toast.LENGTH_SHORT).show()
//    }
    spinner.onItemSelectedListener = object : AdapterView.OnItemSelectedListener {
        override fun onItemSelected(parent: AdapterView<*>?, v: View?, position: Int, id: Long) {
            val selected = parent?.getItemAtPosition(position)?.toString() ?: return
            context?.let { ctx ->
                Toast.makeText(ctx, "Wybrano: $selected", Toast.LENGTH_SHORT).show()
            }
        }
        override fun onNothingSelected(parent: AdapterView<*>?) { /* nic */ }
    }

}
//
//    companion object {
//        /**
//         * Use this factory method to create a new instance of
//         * this fragment using the provided parameters.
//         *
//         * @param param1 Parameter 1.
//         * @param param2 Parameter 2.
//         * @return A new instance of fragment BlankFragmentSecond.
//         */
//        // TODO: Rename and change types and number of parameters
//        @JvmStatic fun newInstance(param1: String, param2: String) =
//                BlankFragmentSecond().apply {
//                    arguments = Bundle().apply {
//                        putString(ARG_PARAM1, param1)
//                        putString(ARG_PARAM2, param2)
//                    }
//                }
//    }
}