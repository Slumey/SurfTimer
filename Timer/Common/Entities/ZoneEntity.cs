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
using Sharp.Shared.Types;
using Source2Surf.Timer.Common.Enums;
using SqlSugar;

namespace Source2Surf.Timer.Common.Entities;

[SugarTable("surf_zones")]
internal sealed class ZoneEntity
{
    [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
    public ulong Id { get; set; }

    public Guid MapId { get; set; }

    public ZoneType Type { get; set; }

    public ushort Track { get; set; }

    public ushort Sequence { get; set; }

    [SugarColumn(IsJson = true)]
    public Vector Mins { get; set; }

    [SugarColumn(IsJson = true)]
    public Vector Maxs { get; set; }

    [SugarColumn(IsJson = true)]
    public Vector Center { get; set; }

    [SugarColumn(IsJson = true)]
    public Vector Angles { get; set; }
}
