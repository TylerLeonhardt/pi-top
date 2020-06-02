﻿using System;
using Microsoft.Psi;
using PiTopMakerArchitecture.Foundation.Sensors;

namespace PiTopMakerArchitecture.Foundation.PSI
{
    public static class SensorComponents
    {
        public static IProducer<double> CreateComponent(this UltrasonicSensor ultrasonicSensor, Pipeline pipeline, TimeSpan samplingInterval) 
        {
            if (ultrasonicSensor == null)
            {
                throw new ArgumentNullException(nameof(ultrasonicSensor));
            }
            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }
            return Generators.Sequence(pipeline, 0.0, _ => ultrasonicSensor.Distance, samplingInterval);
        }

        public static IProducer<bool> CreateComponent(this Button button, Pipeline pipeline, TimeSpan samplingInterval)
        {
            if (button == null)
            {
                throw new ArgumentNullException(nameof(button));
            }
            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }
            return Generators.Sequence(pipeline, false, _ => button.IsPressed, samplingInterval);
        }

        public static IProducer<double> CreateComponent(this LightSensor lightSensor, Pipeline pipeline, TimeSpan samplingInterval)
        {
            if (lightSensor == null)
            {
                throw new ArgumentNullException(nameof(lightSensor));
            }

            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }
            return Generators.Sequence(pipeline, 0.0, _ => lightSensor.Value, samplingInterval);
        }

        public static IProducer<double> CreateComponent(this Potentiometer potentiometer, Pipeline pipeline, TimeSpan samplingInterval)
        {
            if (potentiometer == null)
            {
                throw new ArgumentNullException(nameof(potentiometer));
            }

            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }
            return Generators.Sequence(pipeline, 0.0, _ => potentiometer.Position, samplingInterval);
        }

        public static IProducer<double> CreateComponent(this SoundSensor soundSensor, Pipeline pipeline, TimeSpan samplingInterval)
        {
            if (soundSensor == null)
            {
                throw new ArgumentNullException(nameof(soundSensor));
            }

            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }
            return Generators.Sequence(pipeline, 0.0, _ => soundSensor.Value, samplingInterval);
        }
    }
}
