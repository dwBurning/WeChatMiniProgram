const app = getApp();
var util = require('../../utils/util.js');

Page({
  data: {
    carts: [], // 购物车列表
    hasList: false, // 列表是否有数据
    totalPrice: 0, // 总价，初始为0
    selectAllStatus: true, // 全选状态，默认全选
    sessionKey: '',
    obj: {
      name: "hello"
    }
  },
  onLoad() {

  },

  onShow() {
    const self = this;
    wx.getStorage({
      key: 'sessionKey',
      success: function(res) {
        self.setData({
          sessionKey: res.data
        })
        wx.request({
          url: app.globalData.urlCarts + '?sessionKey=' + self.data.sessionKey,
          success: function(res) {
            if (res.data.Context && res.data.Context.length > 0) {
              self.setData({
                hasList: true, // 既然有数据了，那设为true吧
                carts: res.data.Context
              });
            }
            app.globalData.carts = self.data.carts;
          },
          complete: function(res) {
            self.getTotalPrice()
          }
        });
      },
      fail: function(res) {
        util.checkSession()
      },
    })
  },

  /**
   * 当前商品选中事件
   */
  selectList(e) {
    const index = e.currentTarget.dataset.index;
    let carts = this.data.carts;
    const selected = carts[index].selected;
    carts[index].selected = !selected;
    this.setData({
      carts: carts
    });
    this.getTotalPrice();
  },

  /**
   * 删除购物车当前商品
   */
  deleteList(e) {
    const index = e.currentTarget.dataset.index;
    let carts = this.data.carts;
    let count = carts[index].Count
    let menuId = carts[index].Menu.MenuId;
    carts.splice(index, 1);
    this.setData({
      carts: carts
    });
    if (!carts.length) {
      this.setData({
        hasList: false
      });
    } else {
      this.getTotalPrice();
    }

    wx.request({
      url: app.globalData.urlCarts,
      data: {
        count: count,
        menuId: menuId,
        sessionKey: app.globalData.sessionKey
      },
      method: 'Delete',
      success: function(res) {
        console.log(res);
      }
    })

  },

  /**
   * 购物车全选事件
   */
  selectAll(e) {
    let selectAllStatus = this.data.selectAllStatus;
    selectAllStatus = !selectAllStatus;
    let carts = this.data.carts;

    for (let i = 0; i < carts.length; i++) {
      carts[i].Selected = selectAllStatus;
    }
    this.setData({
      selectAllStatus: selectAllStatus,
      carts: carts
    });
    this.getTotalPrice();
  },

  /**
   * 绑定加数量事件
   */
  addCount(e) {
    const index = e.currentTarget.dataset.index;
    let carts = this.data.carts;
    let num = carts[index].Count;
    num = num + 1;
    carts[index].Count = num;
    this.setData({
      carts: carts
    });
    this.getTotalPrice();
    wx.request({
      url: app.globalData.urlCarts,
      data: {
        menuId: carts[index].Menu.MenuId,
        count: 1,
        sessionKey: app.globalData.sessionKey
      },
      method: 'POST',
      success: function(res) {
        console.log(res);
      }
    })
  },

  /**
   * 绑定减数量事件
   */
  minusCount(e) {
    const index = e.currentTarget.dataset.index;
    const obj = e.currentTarget.dataset.obj;
    let carts = this.data.carts;
    let num = carts[index].Count;
    if (num <= 1) {
      return false;
    }
    num = num - 1;
    carts[index].Count = num;
    this.setData({
      carts: carts
    });
    this.getTotalPrice();

    wx.request({
      url: app.globalData.urlCarts,
      data: {
        menuId: carts[index].Menu.MenuId,
        count: 1,
        sessionKey: app.globalData.sessionKey
      },
      method: 'Delete',
      success: function(res) {
        console.log(res);
      }
    })
  },

  /**
   * 计算总价
   */
  getTotalPrice() {
    let carts = this.data.carts; // 获取购物车列表
    let total = 0;
    for (let i = 0; i < carts.length; i++) { // 循环列表得到每个数据
      if (carts[i].selected) { // 判断选中才会计算价格
        total += carts[i].count * carts[i].menu.Price; // 所有价格加起来
      }
    }
    this.setData({ // 最后赋值到data中渲染到页面
      carts: carts,
      totalPrice: total.toFixed(2)
    });
  },

  /**
   * 获取订单
   */
  toPay() {
    const self = this;
    let orders = new Array();
    let carts = this.data.carts; // 获取购物车列表
    for (let i = 0; i < carts.length; i++) { // 循环列表得到每个数据
      if (carts[i].selected) { // 判断选中订单才包含该商品
        orders.push(carts[i]);
      }
      app.globalData.orders = orders;
    }
  },

})