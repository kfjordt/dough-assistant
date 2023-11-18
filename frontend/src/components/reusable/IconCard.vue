<template>
    <v-icon :scale="1" :fill="props.iconColor" speed="slow" class="icon" :name="iconAsStr" :animation="animation" />
</template>

<script setup lang="ts">
import { PropType } from 'vue';
import { Icons, getIconAsStr } from '../../models/icons/Icons';
import { computed } from '@vue/reactivity';

const props = defineProps({
    icon: {
        type: Number as PropType<Icons>,
        required: true
    },
    isSpinning: {
        type: Boolean
    },
    iconColor: {
        type: String,
        required: true
    }
});

const iconAsStr = computed(() => getIconAsStr(props.icon))
const animation = computed(() => props.isSpinning ? "spin" : undefined)
</script>

<style scoped>
.icon {
    padding: 4px
}
</style>