﻿using Unigram.Common;
using Unigram.Services;
using Unigram.Services.Updates;

namespace Unigram.ViewModels.Settings
{
    public class SettingsGeneralViewModel : UnigramViewModelBase
    {
        private readonly IContactsService _contactsService;

        public SettingsGeneralViewModel(IProtoService protoService, ICacheService cacheService, IEventAggregator aggregator, IContactsService contactsService)
            : base(protoService, cacheService, aggregator)
        {
            _contactsService = contactsService;
        }

        public bool IsSendByEnterEnabled
        {
            get
            {
                return ApplicationSettings.Current.IsSendByEnterEnabled;
            }
            set
            {
                ApplicationSettings.Current.IsSendByEnterEnabled = value;
                RaisePropertyChanged();
            }
        }

        public bool IsReplaceEmojiEnabled
        {
            get
            {
                return ApplicationSettings.Current.IsReplaceEmojiEnabled;
            }
            set
            {
                ApplicationSettings.Current.IsReplaceEmojiEnabled = value;
                RaisePropertyChanged();
            }
        }

        public bool IsAutoPlayEnabled
        {
            get
            {
                return ApplicationSettings.Current.IsAutoPlayEnabled;
            }
            set
            {
                ApplicationSettings.Current.IsAutoPlayEnabled = value;
                RaisePropertyChanged();
            }
        }

        public bool IsWorkModeVisible
        {
            get
            {
                return ApplicationSettings.Current.IsWorkModeVisible;
            }
            set
            {
                ApplicationSettings.Current.IsWorkModeVisible = value;
                RaisePropertyChanged();

                if (!value)
                {
                    ApplicationSettings.Current.IsWorkModeEnabled = false;
                }

                Aggregator.Publish(new UpdateWorkMode(value, ApplicationSettings.Current.IsWorkModeEnabled));
            }
        }
    }
}
