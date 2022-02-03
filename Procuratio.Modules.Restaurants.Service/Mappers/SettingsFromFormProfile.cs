using AutoMapper;
using Procuratio.Modules.Restaurant.Domain.Entities;
using Procuratio.Modules.Restaurant.Service.DTOs.Branch;
using Procuratio.Modules.Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.Service.Mappers
{
    public class SettingsFromFormProfile : Profile
    {
        public SettingsFromFormProfile()
        {
            CreateMap<SettingsFromFormDTO, Branch>()
                .ForMember(x => x.BranchSettings, x => x.MapFrom(MapBranchSettings));
        }

        private List<BranchSetting> MapBranchSettings(SettingsFromFormDTO settingFromFormDTO, Branch branch)
        {
            List<BranchSetting> branchSettings = new();

            foreach (SettingToUpdateDTO item in settingFromFormDTO.SettingsToUpdate)
            {
                BranchSetting branchSetting = branch.BranchSettings.FirstOrDefault(x => x.SettingId == item.SettingId);

                branchSetting.UnconstrainedValue = item.Value;

                branchSettings.Add(branchSetting);
            }

            return branchSettings;
        }
    }
}
