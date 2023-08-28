using Application.Features.DocumentsTypes.Commands.CreateDocumentTypeCommand;
using Application.Features.DocumentsTypes.Querys.GetAllDocumenstsTypesQuery;
using Application.Features.Users.Querys.GetProfileJwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    
    public class DocumentTypeController : BaseApiController
    {
       
        [HttpGet]
        [Route("getAllDocumentTypes")]
        public async Task<IActionResult> GetAllDocumentsTypes()
        {
            return Ok(await Mediator.Send(new GetAllDocumentTypeQuery()));
        }

        [HttpPost]
        [Route("createDocumentType")]
        public async Task<IActionResult> CreateDocumentType(CreateDocumentTypeCommand documentType)
        {
            return Ok(await Mediator.Send(documentType));
        }
    }
}
