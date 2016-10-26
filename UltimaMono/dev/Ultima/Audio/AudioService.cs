/***************************************************************************
 *   AudioService.cs
 *   Copyright (c) 2015 UltimaXNA Development Team
 * 
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 3 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/
#region usings
using UltimaXNA.Core.Audio;
#endregion

namespace UltimaXNA.Ultima.Audio
{
    public class AudioService
    {
        public void Update()
        {
        }

        public void PlaySound(int soundIndex, AudioEffects effect = AudioEffects.None, float volume = 1.0f, bool spamCheck = false)
        {
        }

        public void PlayMusic(int id)
        {
        }

        public void StopMusic()
        {
        }
    }
}
