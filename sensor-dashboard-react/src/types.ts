
export type SensorDto = {
  macAddress: string;
  temperature: string; // comes as string in API
  humidity: string;    // comes as string in API
  lastUpdatedUtc?: string;
}

export type ApiResponse<T> = {
  data: T;
  statusCode: number;
  isSuccess: boolean;
  message: string;
}
