﻿using Microsoft.Xna.Framework;
using System.Runtime.InteropServices;
using System;

// DO NOT include FMOD namespace in ANY of your classes.
// Use FMOD.SomeClass instead.
// FMOD classes seriously interfere with System namespace.

namespace ChaiFoxes.FMODAudio.Studio
{
    /// <summary>
    /// VCA class. Allows for grouping multiple buses together over different group buses, returns, and even events.
    /// </summary>
    public class VCA
    {
        protected FMOD.Studio.VCA _VCA { get; private set; }

        /// <summary>
        /// VCA target volume.
        /// 1 - Normal volume.
        /// 0 - Muted.<para/>
        /// This ignores modulation / automation applied to the volume within Studio.
        /// </summary>
        public float Volume
        {
            get
            {
                _VCA.getVolume(out float volume);
                return volume;
            }
            set =>
                _VCA.setVolume(value);
        }

        /// <summary>
        /// VCA current volume.
        /// 1 - Normal volume.
        /// 0 - Muted.<para/>
        /// This takes into account modulation / automation applied to the volume within Studio.
        /// </summary>
        public float CurrentVolume
        {
            get
            {
                _VCA.getVolume(out _, out float finalVolume);
                return finalVolume;
            }
        }

        /// <summary>
        /// The VCA's internal path, i.e. "vca:/MyVCA".
        /// </summary>
        public string Path
        {
            get
            {
                _VCA.getPath(out string path);
                return path;
            }
        }

        /// <summary>
        /// The VCA's GUID.
        /// </summary>
        public Guid ID
        {
            get
            {
                _VCA.getID(out Guid id);
                return id;
            }
        }

        public VCA(FMOD.Studio.VCA vca)
        {
            _VCA = vca;
        }
    }
}