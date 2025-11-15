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

using System.Data;
using Sharp.Shared.Units;
using SqlSugar;

namespace Source2Surf.Timer.Common.Entities;

internal abstract class BaseSteamIdEntity
{
    [SugarColumn(ColumnName = "steamId", IsPrimaryKey = true, SqlParameterDbType = typeof(SteamIdDataConvert))]
    public SteamID SteamId { get; set; }
}

internal abstract class BaseSteamIdSerialEntity
{
    [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
    public ulong Id { get; set; } 

    [SugarColumn(ColumnName = "steamId", SqlParameterDbType = typeof(SteamIdDataConvert))]
    public SteamID SteamId { get; set; }
}

internal sealed class SteamIdDataConvert : ISugarDataConverter
{
    public SugarParameter ParameterConverter<T>(object columnValue, int columnIndex)
    {
        var name = $"@SteamID{columnIndex}";

        SugarParameter parameter;

        if (columnValue is SteamID id)
        {
            parameter              = new SugarParameter(name, null);
            parameter.CustomDbType = System.Data.DbType.UInt64;
            parameter.DbType       = System.Data.DbType.UInt64;
            parameter.Value        = id.AsPrimitive();
            parameter.TypeName     = "UInt64";
        }
        else if (columnValue is ulong x)
        {
            parameter = new SugarParameter(name, x, System.Data.DbType.UInt64);
        }
        else
        {
            parameter = new SugarParameter(name, null);
        }

        return parameter;
    }

    public T QueryConverter<T>(IDataRecord dataRecord, int dataRecordIndex)
    {
        if (dataRecord.IsDBNull(dataRecordIndex))
        {
            return default!;
        }

        var value   = (ulong) dataRecord.GetValue(dataRecordIndex);
        var steamId = new SteamID(value);

        return (T) (object) steamId;
    }
}
