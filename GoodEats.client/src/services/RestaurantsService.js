import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class RestaurantsService {

  async getAll() {
    const res = await api.get('api/restaurants')
    logger.log(res.data)
    AppState.restaurants = res.data
  }
}

export const restaurantsService = new RestaurantsService()