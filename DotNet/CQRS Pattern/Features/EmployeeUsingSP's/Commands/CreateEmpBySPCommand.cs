﻿using CQRS_Pattern.Models;
using CQRS_Pattern.Models.Request;
using CQRS_Pattern.Models.Response;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CQRS_Pattern.Features.EmployeeUsingSP_s.Commands
{
    public class CreateEmpBySPCommand : CreateEmpRequest, IRequest<ResponseDto>
    {
        public class CreateEmpbySPCommandHandler : IRequestHandler<CreateEmpBySPCommand, ResponseDto>
        {
            private readonly sdirectdbContext _Context;
            public CreateEmpbySPCommandHandler(sdirectdbContext Context)
            {
                _Context = Context;
            }
            public async Task<ResponseDto> Handle(CreateEmpBySPCommand request, CancellationToken cancellationToken)
            {
                ResponseDto res = new ResponseDto();

                var builder = WebApplication.CreateBuilder();
                var conString = builder.Configuration.GetConnectionString("AppConn");

                SqlConnection conn = new SqlConnection(conString);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SP_AstitvaEmp308_Save", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@empName", SqlDbType.VarChar).Value = request.EmpName;
                    cmd.Parameters.Add("@empEmail", SqlDbType.VarChar).Value = request.EmpEmail;
                    cmd.Parameters.Add("@empDob", SqlDbType.Date).Value = request.EmpDob;
                    cmd.Parameters.Add("@empAddress", SqlDbType.VarChar).Value = request.EmpAddress;

                    int iReturn = cmd.ExecuteNonQuery();

                    conn.Close();

                    if(iReturn > 0)
                    {
                        res.StatusCode = 200;
                        res.Message = "Employee Added Successfully.";

                        return res;
                    }
                    else
                    {
                        res.StatusCode = 400;
                        res.Message = "Employee Not Added.";

                        return res;
                    }
                }
                return res;

            }
        }
    }
}
