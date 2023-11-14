<template>
    <Icon :icon="Icons.Spinner" :isSpinning="true" :style="iconStyle" />
</template>

<script setup lang="ts">
import { useStore } from '../../store/store';
import { Icons } from "../../models/icons/Icons"
import Icon from "../reusable/Icon.vue"

const iconStyle = useStore().style.modals.loading
</script>
