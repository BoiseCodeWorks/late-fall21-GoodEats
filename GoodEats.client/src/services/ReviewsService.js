import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class ReviewsService {
  async getByRestaurantId(id) {
    const res = await api.get(`api/restaurants/${id}/reviews`)
    logger.log(res.data)
    AppState.reviews = res.data
  }

  async getByCreatorId(id) {
    const res = await api.get(`api/profiles/${id}/reviews`)
    AppState.profileReviews = res.data
  }
}

export const reviewsService = new ReviewsService()