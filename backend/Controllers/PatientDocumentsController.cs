using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientDocumentsController : ControllerBase
{
    private readonly IPatientDocument _document;

    public PatientDocumentsController(
        IPatientDocument document)
    {
        _document = document;
    }

    [HttpGet]
    public IActionResult GetAllPatientDocument()
    {
        return Ok(_document.GetAllPatientDocument());
    }

    [HttpGet("{id}")]
    public IActionResult GetPatientDocumentById(long id)
    {
        var document = _document.GetPatientDocumentById(id);

        if (document == null)
        {
            return NotFound();
        }

        return Ok(document);
    }

    [HttpPost]
    public IActionResult AddPatientDocument(
        [FromBody] PatientDocument document)
    {
        return Ok(_document.AddPatientDocument(document));
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePatientDocument(
        long id,
        [FromBody] PatientDocument document)
    {
        document.Id = id;

        return Ok(_document.UpdatePatientDocument(document));
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePatientDocumentById(long id)
    {
        var result = _document.DeletePatientDocumentById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}