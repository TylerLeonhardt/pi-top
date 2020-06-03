﻿using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Reactive.Disposables;

using PiTop;

namespace PiTopMakerArchitecture.Foundation
{
    public abstract class DigitalPortDeviceBase : IPiTopConnectedDevice
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        public DigitalPort Port { get; }
        protected GpioController Controller { get; }

        public ICollection<DisplayPropertyBase> DisplayProperties { get; }

        protected DigitalPortDeviceBase(DigitalPort port, IGpioControllerFactory controllerFactory)
        {
            if (controllerFactory == null)
            {
                throw new ArgumentNullException(nameof(controllerFactory));
            }
            DisplayProperties = new List<DisplayPropertyBase>();
            Port = port;
            Controller = controllerFactory.GetOrCreateController();
        }

        protected void AddToDisposables(IDisposable disposable)
        {
            if (disposable == null)
            {
                throw new ArgumentNullException(nameof(disposable));
            }
            _disposables.Add(disposable);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        public void Initialize()
        {
            OnInitialise();
        }

        protected virtual void OnInitialise()
        {

        }
    }
}
