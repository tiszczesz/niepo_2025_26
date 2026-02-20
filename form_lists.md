# ASP.NET MVC (Razor) – przykłady: CheckBox list / Select / Radio

## 1) Model (ViewModel)

```csharp
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

public class FormListsVm
{
    // ========== CHECKBOXY ==========
    // Wybrane ID z listy checkboxów
    [Display(Name = "Zainteresowania")]
    [MinLength(1, ErrorMessage = "Wybierz przynajmniej jedną pozycję.")]
    public List<int> SelectedInterestIds { get; set; } = new();

    // Dostępne opcje do checkboxów (np. z bazy)
    public List<InterestOptionVm> InterestOptions { get; set; } = new();

    // ========== SELECT ==========
    [Display(Name = "Miasto")]
    [Required(ErrorMessage = "Wybierz miasto.")]
    public int? CityId { get; set; }

    public List<SelectListItem> CityOptions { get; set; } = new();

    // ========== RADIO ==========
    [Display(Name = "Preferowany kontakt")]
    [Required(ErrorMessage = "Wybierz preferowany kontakt.")]
    public ContactPreference? Contact { get; set; }
}

public class InterestOptionVm
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}

public enum ContactPreference
{
    Email = 1,
    Phone = 2,
    Sms = 3
}
```

---

## 2) Controller

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

public class FormsController : Controller
{
    [HttpGet]
    public IActionResult Lists()
    {
        var vm = BuildVm();
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Lists(FormListsVm vm)
    {
        // UWAGA: Po POST trzeba ponownie uzupełnić listy opcji,
        // bo nie przychodzą automatycznie z formularza.
        RebuildOptions(vm);

        if (!ModelState.IsValid)
            return View(vm);

        // Tu normalnie zapis do bazy itd.
        // Przykład: pokazanie wyborów
        TempData["msg"] =
            $"CityId={vm.CityId}, Contact={vm.Contact}, Interests=[{string.Join(",", vm.SelectedInterestIds)}]";

        return RedirectToAction(nameof(Lists));
    }

    private FormListsVm BuildVm()
    {
        var vm = new FormListsVm();
        RebuildOptions(vm);
        return vm;
    }

    private void RebuildOptions(FormListsVm vm)
    {
        // Symulacja źródeł danych (np. z bazy)
        var interests = new List<InterestOptionVm>
        {
            new() { Id = 1, Name = "Sport" },
            new() { Id = 2, Name = "Muzyka" },
            new() { Id = 3, Name = "Książki" },
            new() { Id = 4, Name = "Podróże" }
        };

        var cities = new[]
        {
            (Id: 1, Name: "Warszawa"),
            (Id: 2, Name: "Kraków"),
            (Id: 3, Name: "Wrocław"),
        };

        vm.InterestOptions = interests;

        vm.CityOptions = cities
            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
            .ToList();

        // Opcjonalnie: dodaj pustą pozycję na górze selecta
        vm.CityOptions.Insert(0, new SelectListItem { Value = "", Text = "-- wybierz --" });
    }
}
```

---

## 3) View (Razor) – `Lists.cshtml`

```cshtml
@model FormListsVm

@{
    ViewData["Title"] = "Form lists";
}

<h2>@ViewData["Title"]</h2>

@if (TempData["msg"] is string msg)
{
    <div style="padding:8px;border:1px solid #ccc;margin-bottom:12px;">
        @msg
    </div>
}

<form asp-action="Lists" method="post">
    @Html.AntiForgeryToken()

    <div>
        <h3>1) Checkbox list (List&lt;int&gt;)</h3>

        <div asp-validation-summary="ModelOnly"></div>

        @for (var i = 0; i < Model.InterestOptions.Count; i++)
        {
            var opt = Model.InterestOptions[i];

            <div>
                <!-- Kluczowe: name="SelectedInterestIds" i value=Id -->
                <input type="checkbox"
                       name="SelectedInterestIds"
                       value="@opt.Id"
                       @(Model.SelectedInterestIds.Contains(opt.Id) ? "checked" : "") />

                <label>@opt.Name</label>
            </div>
        }

        <span asp-validation-for="SelectedInterestIds"></span>
    </div>

    <hr />

    <div>
        <h3>2) Select (DropDownListFor)</h3>

        @Html.LabelFor(m => m.CityId)
        @Html.DropDownListFor(m => m.CityId, Model.CityOptions, new { @class = "form-select" })
        @Html.ValidationMessageFor(m => m.CityId)
    </div>

    <hr />

    <div>
        <h3>3) Radio buttons (RadioButtonFor)</h3>

        @Html.LabelFor(m => m.Contact)

        <div>
            <label>
                @Html.RadioButtonFor(m => m.Contact, ContactPreference.Email) Email
            </label>
        </div>

        <div>
            <label>
                @Html.RadioButtonFor(m => m.Contact, ContactPreference.Phone) Telefon
            </label>
        </div>

        <div>
            <label>
                @Html.RadioButtonFor(m => m.Contact, ContactPreference.Sms) SMS
            </label>
        </div>

        @Html.ValidationMessageFor(m => m.Contact)
    </div>

    <hr />

    <button type="submit">Wyślij</button>
</form>

@section Scripts {
    <!-- Jeśli używasz walidacji po stronie klienta, upewnij się że masz:
         jquery + jquery.validate + jquery.validate.unobtrusive -->
}
```

---

## 4) Wariant bardziej “MVC-owy” dla checkboxów (EditorTemplate)

Jeśli chcesz ładny binding `List<InterestCheckboxItemVm>` (z `IsSelected`), zrób tak:

### Model elementu
```csharp
public class InterestCheckboxItemVm
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public bool IsSelected { get; set; }
}
```

### W głównym VM
```csharp
public List<InterestCheckboxItemVm> Interests { get; set; } = new();
```

### EditorTemplate `Views/Shared/EditorTemplates/InterestCheckboxItemVm.cshtml`
```cshtml
@model InterestCheckboxItemVm

<input asp-for="IsSelected" type="checkbox" />
<input asp-for="Id" type="hidden" />
<input asp-for="Name" type="hidden" />
<span>@Model.Name</span>
```

### W widoku
```cshtml
@Html.EditorFor(m => m.Interests)
```

Po POST masz listę z `IsSelected=true/false` dla każdego elementu i nie musisz “kombinować” z name/value.