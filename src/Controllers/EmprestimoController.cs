﻿using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Data;
using Web_Library.Data;
using Web_Library.Models;
using Web_Library.Services;


namespace Web_Library.Controllers;

[Authorize]
public class EmprestimoController : Controller
{
    private readonly DataContext _context;
    private readonly UserService _userService;


    public EmprestimoController(DataContext context,IMemoryCache memoryCache,UserService userService)
    {
        _context = context;
        _userService = userService;

    }
    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<EmprestimosModel> emprestimos = _context.Emprestimos;
        return View(emprestimos);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }     

    [HttpPost]
    public IActionResult Create(EmprestimosModel model)
    {
        model.FuncionarioId = _userService.GetIdUser(User.Identity.Name);

       

           
            _context.Emprestimos.Add(model);
            _context.SaveChanges();
            TempData["msgDeSucesso"] = "Emprestimo Cadastrado com Sucesso!";
            return RedirectToAction("Index");
            
        



    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        EmprestimosModel? emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

        if (emprestimo == null) { return NotFound(); }

        return View(emprestimo);
    }

    [HttpPost]
    public IActionResult Edit(EmprestimosModel model)
    {
        if(ModelState.IsValid)
        {
            var emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == model.Id);
            emprestimo.Recebedor = model.Recebedor;
            emprestimo.Livro = model.Livro;
            emprestimo.Fornecedor = model.Fornecedor;
            _context.Emprestimos.Update(emprestimo);
            _context.SaveChanges();
            TempData["msgDeSucesso"] = "Emprestimo Atualizado com Sucesso!";
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if(id == null || id == 0)
        {
            return NotFound();
        }
        EmprestimosModel? emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

        if(emprestimo == null) { return NotFound(); }

        
        return View(emprestimo);
    }

    [HttpPost]
            public IActionResult Delete(EmprestimosModel model)
    {

                _context.Emprestimos.Remove(model);
                _context.SaveChanges();
        TempData["msgDeSucesso"] = "Emprestimo Removido com Sucesso!";
             return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Exportar()
    {
        var dados = GetData();
        using(XLWorkbook wb = new XLWorkbook())
        {

            wb.AddWorksheet(dados,"Emprestimos de Livos");
            using (MemoryStream stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Emprestimos.xlsx");
            }
        }

    }

    private DataTable GetData()
    {
        DataTable dt = new DataTable();
        dt.TableName = "Dados Emprestimos";
        dt.Columns.Add("Recebedor", typeof(string));
        dt.Columns.Add("Fornecedor", typeof(string));
        dt.Columns.Add("Livro", typeof(string));
        dt.Columns.Add("Data Emprestimo", typeof(DateTime));
        var dados = _context.Emprestimos.ToList();
       if(dados.Count > 0)
        {
            foreach (var item in dados)
            {
                dt.Rows.Add(item.Recebedor, item.Fornecedor, item.Livro, item.DataEmprestimo);
            }
        }
        return dt;

    }




}