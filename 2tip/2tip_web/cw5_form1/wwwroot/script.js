//reakcja na zdarzenie onSubmit formularza 3
 document.querySelector(".alert").style.display = "none";
//const form = document.forms[0];
const form = document.querySelector("form");
const checkbox = document.getElementById("agree");
form.addEventListener("submit", function(event){
    if(document.querySelector("#agree:checked") === null){
       // alert("Musisz zaakceptować regulamin!");
       document.querySelector(".alert").style.display = "block";
        event.preventDefault();
    }else{
       document.querySelector(".alert").style.display = "none";
    }
});
console.log(form);
