using Asp_net_Core_API_Assignment_1.Application.DTOs;
using Asp_net_Core_API_Assignment_1.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Asp_net_Core_API_Assignment_1.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController(ITaskServices taskServices) : Controller
    {
        private readonly ITaskServices _services = taskServices;

        [HttpPost(Name = "create-new-task")]
        public IActionResult Create([FromBody] TaskDTO taskDTO)
        {
            try
            {
                return Ok(_services.CreateNewTask(taskDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(Name = "get-tasks")]
        public IActionResult Get()
        {
            List<TaskDTO> tasks = _services.GetAllTasks();
            if (tasks.Count == 0)
            {
                return NotFound("The list is empty");
            }
            return Ok(tasks);
        }

        [HttpGet("{id}", Name = "get-task-by-id")]
        public IActionResult GetById(string id)
        {
            try
            {
                TaskDTO? task = _services.GetTaskById(Guid.Parse(id));
                if (task == null)
                {
                    return NotFound("Cannot find mathing id");
                }
                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{title}", Name = "delete-task")]
        public IActionResult Delete(string title)
        {
            try
            {
                TaskDTO? deleted = _services.DeleteTask(title);
                if (deleted == null)
                {
                    return NotFound($"Cannot find mathing title {title}");
                }
                return Ok(deleted);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{title}", Name = "edit-task")]
        public IActionResult Edit(string title, [FromBody] TaskDTO taskDTO)
        {
            try
            {
                var updatedTask = _services.UpdateTaskById(title, taskDTO); // Assume `UpdateTask` exists in the service
                if (updatedTask == null)
                {
                    return NotFound($"Task with title {title} not found.");
                }
                return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("bulk", Name = "bulk-add-tasks")]
        public IActionResult BulkAdd([FromBody] List<TaskDTO> taskDTOs)
        {
            try
            {
                List<TaskDTO> addedTasks = _services.CreateNewTasks(taskDTOs); // Assume `AddMultipleTasks` exists in the service
                return Ok(addedTasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("bulk", Name = "bulk-delete-tasks")]
        public IActionResult BulkDelete([FromBody] List<string> titles)
        {
            try
            {
                List<TaskDTO> deleted = _services.DeleteTasks(titles);
                if (deleted.Count == 0)
                {
                    return NotFound($"Cannot find mathing titles to delete");
                }
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
