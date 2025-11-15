/*
 * Source2Surf/Timer
 * Copyright (C) 2025 Nukoooo and Kxnrl
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Affero General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Affero General Public License for more details.
 *
 * You should have received a copy of the GNU Affero General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using Source2Surf.Timer.Common.Enums;
using SqlSugar;

namespace Source2Surf.Timer.Common.Entities;

[SugarTable("surf_runs")]
internal sealed class RunEntity : BaseSteamIdSerialEntity
{
    public Guid     MapId   { get; set; }
    public RunStyle Style   { get; set; }
    public ushort   Track   { get; set; }
    public double   Time    { get; set; }
    public uint     Jumps   { get; set; }
    public uint     Strafes { get; set; }
    public double   Sync    { get; set; }

    [SugarColumn(ColumnName = "velStart")]
    public double VelocityStart { get; set; }

    [SugarColumn(ColumnName = "velEnd")]
    public double VelocityEnd { get; set; }

    [SugarColumn(ColumnName = "velMax")]
    public double VelocityMax { get; set; }

    [SugarColumn(ColumnName = "velAvg")]
    public double VelocityAvg { get; set; }

    public DateTime Date { get; set; }
}
