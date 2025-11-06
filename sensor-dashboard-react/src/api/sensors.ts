
import { useQuery } from '@tanstack/react-query'
import api from './client'
import type { ApiResponse, SensorDto } from '../types'

export function useSensors() {
  return useQuery({
    queryKey: ['sensors'],
    queryFn: async (): Promise<SensorDto[]> => {
      const res = await api.get<ApiResponse<SensorDto[]>>('/api/v1/sensor/list?Limit=10')
      if (!res.data.isSuccess) throw new Error(res.data.message)
      return res.data.data
    },
    refetchInterval: 1000,
    refetchIntervalInBackground: true, // ✅ continue updating even if data unchanged
    staleTime: 0,                       // ✅ always allow refresh
  })
}
