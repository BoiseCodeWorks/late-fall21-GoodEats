<template>
  <div class="modal" tabindex="-1">
    <div :class="size" class="modal-dialog">
      <div class="modal-content">
        <div class="modal-body">
          <slot name="modal-body"></slot>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  props: {
    size: {
      type: String,
      default: 'modal-dialog'
    }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
</style>