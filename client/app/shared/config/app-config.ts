
export let DEFAULT_APP_CONFIG: AppConfig = {
  baseUrls: {
    portfolio: 'portfolio',
    watchList: 'watch-list',
    sectors: 'sectors'
  }
}

export interface AppConfig {
  baseUrls: BaseUrls
}

export interface BaseUrls {
  portfolio: string;
  watchList: string;
  sectors: string;
}

