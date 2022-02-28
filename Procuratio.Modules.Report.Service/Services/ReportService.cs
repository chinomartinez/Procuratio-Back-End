using Procuratio.Modules.Order.Shared;
using Procuratio.Modules.Order.Shared.DTO;
using Procuratio.Modules.Report.Service.DTOs;
using Procuratio.Modules.Report.Service.Services.Interfaces;
using Procuratio.Shared.ProcuratioFramework.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Report.Service.Services
{
    internal class ReportService : IReportService
    {
        private readonly IOrderModuleAPI _orderModuleAPI;

        public ReportService(IOrderModuleAPI orderModuleAPI)
        {
            _orderModuleAPI = orderModuleAPI;
        }

        public async Task<ReportDTO> GetOrderForReport(int from, int to)
        {
            ReportDTO reportDTO = new();

            reportDTO.OrderReport = await BuildOrderReport(from, to);

            // AGREGAR LA OPCION DE INDICAR SI ES BEBIDA O NO Y TERMINAR LOS FILTROS

            reportDTO.BestSellingMeal = await BuildBestSellingMealReport();
            //reportDTO.WorstSellingMeal = await BuildWorstSellingMealReport();

            //reportDTO.BestSellingDrink = await BuildBestSellingDrinkReport();
            //reportDTO.WorstSellingDrink = await BuildWorstSellingDrinkReport();

            return reportDTO;
        }

        private async Task<List<MultiDTO>> BuildOrderReport(int from, int to)
        {
            List<MultiDTO> multiDTOs = new();

            List<OrderForReportDTO> ordersForReport = await _orderModuleAPI.GetOrderForReport(from, to);

            List<int> years = new();

            ordersForReport.ForEach(x => { if (!years.Contains(x.Year)) years.Add(x.Year); });

            foreach (object currentMonth in Enum.GetValues(typeof(Month)))
            {
                MultiDTO currentMultiDTO = new()
                {
                    Name = currentMonth.ToString(),
                    Series = new List<SeriesDTO>()
                };

                foreach (int currentYear in years)
                {
                    int totalOrdersPaid = 0;

                    if (ordersForReport.Exists(x => x.Month == (int)currentMonth && x.Year == currentYear))
                    {
                        totalOrdersPaid = ordersForReport.Find(x => x.Month == (int)currentMonth && x.Year == currentYear).Quantity;

                        ordersForReport.RemoveAll(x => x.Month == (int)currentMonth && x.Year == currentYear);
                    }

                    currentMultiDTO.Series.Add(new SeriesDTO()
                    {
                        Name = currentYear.ToString(),
                        Value = totalOrdersPaid
                    });
                }

                multiDTOs.Add(currentMultiDTO);
            }

            return multiDTOs;
        }

        private async Task<List<SeriesDTO>> BuildBestSellingMealReport()
        {
            List<SeriesDTO> seriesDTOs = new();

            List<ItemForReportDTO> itemForReport = await _orderModuleAPI.GetItemForBestSellingMeal();

            itemForReport.ForEach(x => seriesDTOs.Add(new SeriesDTO() { Name = x.Name, Value = x.Value }));

            return seriesDTOs;
        }

        private async Task<List<SeriesDTO>> BuildWorstSellingMealReport()
        {
            List<SeriesDTO> seriesDTOs = new();

            List<ItemForReportDTO> itemForReport = await _orderModuleAPI.GetItemForWorstSellingMeal();

            return null;
        }

        private async Task<List<SeriesDTO>> BuildBestSellingDrinkReport()
        {
            List<SeriesDTO> seriesDTOs = new();

            List<ItemForReportDTO> itemForReport = await _orderModuleAPI.GetItemForBestSellingDrink();

            return null;
        }

        private async Task<List<SeriesDTO>> BuildWorstSellingDrinkReport()
        {
            List<SeriesDTO> seriesDTOs = new();

            List<ItemForReportDTO> itemForReport = await _orderModuleAPI.GetItemForWorstSellingDrink();

            return null;
        }
    }
}
